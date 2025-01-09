﻿namespace DDFinancePolicy.Web.Policies;

public class DeletePolicyRequest
{
  public const string Route = "/Policies/{PolicyId:int}";
  public static string BuildRoute(int policyId) => Route.Replace("{PolicyId:int}", policyId.ToString());

  public int PolicyId { get; set; }
}
